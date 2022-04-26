using Xunit;

namespace MathildeStringTest;

public class UnitTest1
{
    [Theory]
    [InlineData("toto")]
    [InlineData("")]
    public void ToString_ShouldReturnASystemString(string s1)
    {
        MathildeString.String first = new MathildeString.String(s1);

        var actual = first.ToString();

        Assert.IsType<string>(actual);
    }

    [Theory]
    [InlineData("toto")]
    [InlineData("")]
    public void Length_ShouldReturnTheLengthOfTheNumberOfCharactersIntheString(string s1)
    {
        MathildeString.String first = new MathildeString.String(s1);
        int expected = s1.Length;

        int actual = first.Length;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("toto", 3)]
    public void GetIndex_ShouldReturnTheCharacterOfTheGivenIndex(string s1, int index)
    {
        MathildeString.String first = new MathildeString.String(s1);
        char expected = s1[index];

        char actual = first[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("toto", 'o')]
    [InlineData("toto", 'a')]
    public void IndexOf_ShouldReturnTheIndexOfTheGivenCharacter(string s1, char c1)
    {
        MathildeString.String first = new MathildeString.String(s1);
        int expected = s1.IndexOf(c1);

        int actual = first.IndexOf(c1);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("toto", "tata")]
    [InlineData("", "tata")]
    [InlineData("toto", "")]
    public void Concat_ShouldReturnTwoStringsConcatenated(string s1, string s2)
    {
        MathildeString.String first = new MathildeString.String(s1);
        MathildeString.String second = new MathildeString.String(s2);
        MathildeString.String expected = new MathildeString.String(string.Concat(s1, s2));

        MathildeString.String actual = MathildeString.String.Concat(first, second);

        actual.Equals(expected);
    }

    [Theory]
    [InlineData("toto", " ", 2)]
    [InlineData("tata", "tutu", 0)]
    public void Insert_ShouldReturnANewStringWithInsertedValues(string s1, string s2, int index)
    {
        MathildeString.String first = new MathildeString.String(s1);
        MathildeString.String second = new MathildeString.String(s2);
        MathildeString.String expected = new MathildeString.String(s1.Insert(index, s2));

        MathildeString.String actual = first.Insert(index, second);

        actual.Equals(expected);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("tata", "tata")]
    public void Equals_ShouldReturnTrueIfTwoStringsHaveSameContent(string s1, string s2)
    {
        MathildeString.String first = new MathildeString.String(s1);
        MathildeString.String second = new MathildeString.String(s2);
        bool expected = true;

        bool actual = first.Equals(second);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("tut", "")]
    [InlineData("tata", "taa")]
    public void Equals_ShouldReturnFalseIfTwoStringsHaveNotTheSameContent(string s1, string s2)
    {
        MathildeString.String first = new MathildeString.String(s1);
        MathildeString.String second = new MathildeString.String(s2);
        bool expected = false;

        bool actual = first.Equals(second);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("tata", "tata")]
    public void Equals_ShouldReturnTrueIfTwoObjectsHaveSameContent(string s1, object o1)
    {
        MathildeString.String first = new MathildeString.String(s1);
        bool expected = true;

        bool actual = first.Equals(o1);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("tut", null)]
    [InlineData("tata", "tat")]
    [InlineData("tata", 1)]
    public void Equals_ShouldReturnFalseIfTwoSObjectsHaveNotTheSameContent(string s1, object o1)
    {
        MathildeString.String first = new MathildeString.String(s1);
        bool expected = false;

        bool actual = first.Equals(o1);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("tata", "tata")]
    [InlineData("", "")]
    public void GetHashCode_ShouldReturnSameValueForTwoStringsWithSameContent(string s1, string s2)
    {
        MathildeString.String first = new MathildeString.String(s1);
        MathildeString.String second = new MathildeString.String(s2);
        bool expected = true;

        bool actual = first.GetHashCode().Equals(second.GetHashCode());

        Assert.Equal(expected, actual);
    }
}
