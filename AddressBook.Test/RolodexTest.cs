
using NSubstitute;
using NUnit.Framework;

namespace AddressBook.Test
{
    [TestFixture]
    public class RolodexTest
    {
        private IGetInputFromUser _input;
        private IHandleContacts _contacts;
        private IHandleRecipes _recipes;
        private Rolodex _rolodex;

        [SetUp]
        public void BeforeEachTest()
        {
            _input = Substitute.For<IGetInputFromUser>();
            _contacts = Substitute.For<IHandleContacts>();
            _recipes = Substitute.For<IHandleRecipes>();
            _rolodex = new Rolodex(_contacts, _recipes, _input);
        }

        [Test]
        public void ExitJustDoesNothing()
        {

            //Arrang

            _input.GetNumber().Returns(0);

            //Act
            _rolodex.DoStuff();
            //Assert
            _input.Received().GetNumber();
            _contacts.DidNotReceive().GetAllContacts();
            _recipes.DidNotReceive().GetAllRecipes();
            _contacts.DidNotReceiveWithAnyArgs().CreateCompany(null, null);
        }
        [Test]
        public void AddPersonAddsAPersonJustLikeYouWouldExpectItTo()
        {
            //Arrange

            _input.GetNumber().Returns(1, 0);
            _input.GetNonEmptyString().Returns("Bob", "Mills", "555/444*1111");
            _rolodex.DoStuff();

            //Assert
            _input.Received(2).GetNumber();
            _contacts.DidNotReceive().GetAllContacts();
            _recipes.DidNotReceive().GetAllRecipes();
            _contacts.DidNotReceiveWithAnyArgs().CreateCompany(null, null);
            _contacts.Received().CreatePerson("Bob", "Mills", "555/444*1111");
        }
        [Test]
        public void AddRecipeAddsARecipeJustLikeYouWouldExpectItTo()
        {
            //Arrange

            _input.GetNumber().Returns(6,2,0);
            _input.GetNonEmptyString().Returns("Apple Pie");

            _rolodex.DoStuff();

            //Assert
            _input.Received(3).GetNumber();
            _contacts.DidNotReceive().GetAllContacts();
            _recipes.DidNotReceive().GetAllRecipes();
            _contacts.DidNotReceiveWithAnyArgs().CreateCompany(null, null);
            _recipes.Received().Create("Apple Pie",RecipeType.Desserts);
        }
    }
}
