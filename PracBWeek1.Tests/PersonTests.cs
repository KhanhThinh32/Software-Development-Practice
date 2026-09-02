using Xunit;

public class PersonTests
{
    [Fact]
    public void FullName_ReturnsExpectedFormat()
    {
        Person person = new Person("Khanh", "Thinh", 22);
        string result = person.FullName();
        Assert.Equal("Khanh Thinh", result);
    }

    [Fact]
    public void IsAdult_ReturnsTrue_WhenAge18OrMore()
    {
        Person person = new Person("Khanh", "Long", 18);
        bool result = person.IsAdult();
        Assert.True(result);
    }
}
