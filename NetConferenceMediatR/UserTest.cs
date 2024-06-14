using NetConferenceMediatR.API.User;

namespace NetConferenceMediatR
{
    [TestClass]
    public class UserTest : MediatorTestBase
    {
        [TestMethod]
        public async Task Should_Add_New_User()
        {
            var payload = new AddUserPayload("Max", "Template", "max@gmail.com", DateTime.UtcNow.AddYears(-20));
            var addUserResponse = await Mediator.Send(new AddUser(payload));

            Assert.IsNotNull(addUserResponse);
        }

        [TestMethod]
        public async Task Should_Get_User_By_Id()
        {
            var user = await Mediator.Send(new GetUserById(2));
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task Should_Get_All_Users()
        {
            var users = await Mediator.Send(new GetUsers());
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public async Task Should_Update_User_By_Id()
        {
            var payload = new UpdateUserPayload(string.Empty, string.Empty, "myNewEmail@gmail.com");
            var user = await Mediator.Send(new UpdateUser(2, payload));

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task Should_Delete_User_By_Id()
        {
            var deleteResult = await Mediator.Send(new DeleteUserById(2));
            Assert.IsTrue(deleteResult.Success);

            var getUsersResponse = await Mediator.Send(new GetUsers());
            Assert.AreEqual(2, getUsersResponse.Users.Count);
        }
    }
}