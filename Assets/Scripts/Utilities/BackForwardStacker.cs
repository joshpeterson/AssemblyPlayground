using System.Collections.Generic;
using System.Linq;

public class BackForwardStacker<T>
{
  private readonly Stack<T> _backStack = new Stack<T>();
  private readonly Stack<T> _forwardStack = new Stack<T>();

  public T PopBack()
  {
    var value = _backStack.Pop();
    _forwardStack.Push(value);
    return value;
  }

  public T PopForward()
  {
    var value = _forwardStack.Pop();
    return value;
  }

  public void PushBack(T value)
  {
    _backStack.Push(value);
  }

  public bool CanGoBack()
  {
    return _backStack.Any();
  }

  public bool CanGoForward()
  {
    return _forwardStack.Any();
  }
}