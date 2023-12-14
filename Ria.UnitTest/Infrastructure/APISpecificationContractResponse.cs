using System;
using System.Diagnostics.CodeAnalysis;

namespace Ria.UnitTest.Unit.Tests.Infrastructure
{
    public readonly struct APISpecificationContractResponse : IEquatable<APISpecificationContractResponse>
    {
        public readonly APIScpecificationContent OriginalContent { get; }
        public readonly APIScpecificationContent ApplicationContent { get; }

        public APISpecificationContractResponse(APIScpecificationContent originalContent, APIScpecificationContent applicationContent)
        {
            OriginalContent = originalContent;
            ApplicationContent = applicationContent;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is APISpecificationContractResponse other))
            {
                return false;
            }
            return OriginalContent.Equals(other.OriginalContent) &&
                   ApplicationContent.Equals(other.ApplicationContent);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals([AllowNull] APISpecificationContractResponse other)
        {
            return OriginalContent.Equals(other.OriginalContent) &&
                    ApplicationContent.Equals(other.ApplicationContent);
        }

        public static bool operator ==(APISpecificationContractResponse a, APISpecificationContractResponse b) => a.Equals(b);

        public static bool operator !=(APISpecificationContractResponse a, APISpecificationContractResponse b) => !a.Equals(b);
    }

    public readonly struct APIScpecificationContent : IEquatable<APIScpecificationContent>
    {
        public readonly string Content { get; }

        public APIScpecificationContent(string content)
        {
            Content = content;
        }

        public bool Equals([AllowNull] APIScpecificationContent other)
        {
            return Content.Equals(other.Content);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is APIScpecificationContent other))
            {
                return false;
            }
            return Content.Equals(other.Content);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(APIScpecificationContent a, APIScpecificationContent b) => a.Equals(b);

        public static bool operator !=(APIScpecificationContent a, APIScpecificationContent b) => !a.Equals(b);
    }
}
