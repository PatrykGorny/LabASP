using Microsoft.VisualBasic.CompilerServices;

namespace Lab_ASP_1.Models;

public class Calculator
{
    public Operators? Operator { get; set; }
    public double? a { get; set; }
    public double? b { get; set; }

    public string Op
    {
        get
        {
            switch (Operator)
            {
                case Operators.Add:
                    return "+";
                case Operators.Sub:
                    return "-";
                case Operators.Mul:
                    return "*";
                case Operators.Div:
                    return "/";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && a != null && b != null && (Operator != Operators.Div || b != 0);
    }

    public double Calculate()
    {
        switch (Operator)
        {
            case Operators.Add:
                return (double)(a + b);
            case Operators.Sub:
                return (double)(a - b);
            case Operators.Mul:
                return (double)(a * b);
            case Operators.Div:
                return (double)(a / b);
            default:
                return double.NaN;
        }
    }

    public enum Operators
    {
        Add,
        Sub,
        Mul,
        Div
    }
}
