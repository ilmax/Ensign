using System.Collections.Generic;
using System.Text;
using EnsignLib.Core.Interfaces;

namespace EnsignLib.Core
{
    public class FeatureHydrator : IFeatureHydrator
    {
        private const char MajorDiv = '|';
        private const char MinorDiv = ':';

        public string DehydrateToString(IFeature feature)
        {
            var sb = new StringBuilder();

            sb.Append(feature.Name);
            sb.Append(MajorDiv);
            sb.Append(feature.GlobalPercentage);

            foreach (var group in feature.Groups())
            {
                sb.Append(MajorDiv);
                sb.Append(group.Name);

                foreach (var userId in group.Users)
                {
                    sb.Append(MinorDiv);
                    sb.Append(userId);
                }
            }

            return sb.ToString();
        }

        public IFeature HydrateFrom(string dehydratedFeature, IBackingStore backingStore)
        {
            try
            {
                var majorChunks = dehydratedFeature.Split(MajorDiv);

                var name = string.Empty;
                var percentage = 0;
                var groups = new List<IGroup>();

                for (var i = 0; i < majorChunks.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            name = majorChunks[0];
                            break;
                        case 1:
                            percentage = int.Parse(majorChunks[1]);
                            break;
                        default:
                            groups.Add(ParseGroup(majorChunks[i]));
                            break;
                    }
                }

                return new Feature(backingStore, name, percentage, groups);
            }
            catch
            {
                throw new HydrationException(
                    "Could not rehydrate feature from string. Please check the format.",
                    dehydratedFeature);
            }
        }

        private static IGroup ParseGroup(string groupString)
        {
            var minorChunks = groupString.Split(MinorDiv);
            IGroup group = null;

            for (var j = 0; j < minorChunks.Length; j++)
            {
                if (j == 0)
                {
                    group = new Group(minorChunks[0]);
                }
                else
                {
                    group.AddUser(minorChunks[j]);
                }
            }

            return group;
        }
    }
}
