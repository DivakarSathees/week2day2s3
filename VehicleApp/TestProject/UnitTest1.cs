namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFolderExists()
    {
        // Arrange
        string folderPath = @"/home/coder/project/workspace/DLL/TestProject";

        // Act
        bool folderExists = Directory.Exists(folderPath);

        // Assert
        Assert.IsTrue(folderExists, $"Folder '{folderPath}' does not exist.");
    }
}