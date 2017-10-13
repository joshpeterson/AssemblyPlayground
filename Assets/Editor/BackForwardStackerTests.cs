using NUnit.Framework;

public class BackForwardStackerTests
{
  readonly BackForwardStacker<int> _stacker = new BackForwardStacker<int>();

  [Test]
  public void CanGoBackIsFalseByDefault()
  {
    Assert.That(_stacker.CanGoBack(), Is.False,
      "CanGoBack is not false by default, which is not expected.");
  }
  
  [Test]
  public void CanGoBackIsTrueAfterAddingEntry()
  {
    _stacker.PushBack(42);
    Assert.That(_stacker.CanGoBack(), Is.True,
      "CanGoBack is not true after adding an entry, which is not expected.");
  }
  
  [Test]
  public void CanGoBackIsFalseAfterAddingAndRemovingEntry()
  {
    _stacker.PushBack(42);
    _stacker.PopBack();

    Assert.That(_stacker.CanGoBack(), Is.False,
      "CanGoBack is not false after removing all entries, which is not expected.");
  }

  [Test]
  public void PopBackReturnsTheLastPushedEntry()
  {
    _stacker.PushBack(42);
    _stacker.PushBack(43);
    
    const int expected = 44;
    _stacker.PushBack(expected);
    
    Assert.That(_stacker.PopBack(), Is.EqualTo(expected),
      "PopBack did not return the last pushed entry, which is not expected.");
  }
  
  [Test]
  public void CanGoForwardIsFalseByDefault()
  {
    Assert.That(_stacker.CanGoForward(), Is.False,
      "CanGoForward is not false by default, which is not expected.");
  }
  
  [Test]
  public void CanGoForwardIsTrueAfterAPopBack()
  {
    _stacker.PushBack(42);
    _stacker.PopBack();
    
    Assert.That(_stacker.CanGoForward(), Is.True,
      "CanGoForward is not true by after a pop back, which is not expected.");
  }
  
  [Test]
  public void PopForwardReturnsTheLastPopBackedEntry()
  {
    _stacker.PushBack(42);
    _stacker.PushBack(43);
    
    const int expected = 44;
    _stacker.PushBack(expected);

    _stacker.PopBack();
    
    Assert.That(_stacker.PopForward(), Is.EqualTo(expected),
      "PopForward did not return the lasy pop backed entry, which is not expected.");
  }
}