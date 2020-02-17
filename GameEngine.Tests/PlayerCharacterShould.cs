using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        private readonly ITestOutputHelper _output;
        private readonly PlayerCharacter _sut;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating New PlayerCharacter");
            _sut = new PlayerCharacter();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter p = new PlayerCharacter();

            Assert.True(p.IsNoob);

        }

        [Fact]
        public void CalculateFullName()
        {

            _sut.FirstName = "Diego";
            _sut.LastName = "Martins";

            Assert.Equal("Diego Martins", _sut.FullName);

        }

        [Fact]
        public void StartWithDefaultHealth()
        {

            Assert.Equal(100, _sut.Health);

        }

        [Fact]
        public void IncreaseHealthAfterSleep()
        {

            _sut.Sleep();

            Assert.InRange<int>(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {

            Assert.Null(_sut.Nickname);
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void RaiseSleptEvent()
        {

            Assert.Raises<EventArgs>(
                  handler => _sut.PlayerSlept += handler,
                  handler => _sut.PlayerSlept -= handler,
                  () => _sut.Sleep());
        }

        [Theory]
        //[InlineData(0, 100)]
        //[InlineData(1, 99)]
        //[InlineData(50, 50)]
        //[InlineData(101, 1)]
        [MemberData(nameof(InternalHealthDamageTesteData.TestData),
            MemberType = typeof(InternalHealthDamageTesteData))]
        public void TakeDamage(int demage, int expectedHealth)
        {
            _sut.TakeDamage(demage);

            Assert.Equal(expectedHealth, _sut.Health);
        }

    }
}
