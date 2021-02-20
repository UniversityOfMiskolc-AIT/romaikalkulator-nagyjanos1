

public class NumberFactory 
{
  private readonly List<KeyValuePair<char, Type>> romanNumbersDomain = new List<KeyValuePair<char, Type>> 
  {
    { 'i', typeof(CharOne) },
    { 'v', typeof(CharFive) },
    // { 'x', typeof(CharTen) },
    // { 'l', typeof(CharFifty) },
    // { 'c', typeof(CharHundred) },
    // { 'm', typeof(CharThousand) }
  };

  public Number CreateFlyWeight(char character) 
  {    
    if (romanNumbersDomain.keys.Contains(character)) {
      return Activator.Create();
    }

    return null;
  }
}

public class Number 
{ 
  public double Value { get; private set; }

  public Number(double value) 
  {
    Value = value
  }

  public static Number operator +(Number a, Number b) => new Number(a.Value + b.Value);
  public static Number operator -(Number a, Number b) => new Number(a.Value - b.Value);
  public static Number operator *(Number a, Number b) => new Number(a.Value * b.Value);
  public static Number operator /(Number a, Number b) => new Number(a.Value / b.Value);
}

public class CharOne : Number
{
  public const double Value = 1.0;

  public CharOne() : base(Value)
  {      
  }

}

public class CharFive : Number
{
  public const double Value = 5.0;

  public CharFive() : base(value)
  {
      
  }
}
