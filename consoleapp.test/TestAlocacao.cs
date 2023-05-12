using consoleapp.lib;

namespace consoleapp.test;
public class TestAlocacao
{

    [Test]
    public void TestReverse()
    {
       
       //arrange
        var old = new List<int>{1,90000,4};
        var expected =  new List<int>{4,90000,1};

        var list = new List<int>{1,90000,4};
       //act
        Reverse.Do(list);

       //asserts
        Assert.True(old.ToArray()[0] == list.ToArray()[list.Count() - 1]);
        Assert.AreEqual(list,expected);
    }
}