using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Core.Unit.Tests.Shared
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new CompositeCustomization(new AutoMoqCustomization(), new SupportMutableValueTypesCustomization())))
        {
        }
    }
}
