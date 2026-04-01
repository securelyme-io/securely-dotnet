namespace Securely.Subscriptions.Types;
/// <summary>
/// The frequency that the subscription should pull payment
/// </summary>
public sealed class Frequency {
    private readonly string _value;

    /// <summary>
    /// The frequency that the subscription should pull payment
    /// </summary>
    public Frequency(string value) {
        _value = value;
    }

    /// <summary>
    /// Frequency happens every week
    /// </summary>
    public static readonly Frequency Weekly = new("WEEKLY");

    /// <summary>
    /// Frequency happens every other week
    /// </summary>
    public static readonly Frequency EveryOtherWeek = new("EVERY OTHER WEEK");

    /// <summary>
    /// Frequency happens on the 1st and 15th of each month
    /// </summary>
    public static readonly Frequency BiMonthly = new("BIMONTHLY");

    /// <summary>
    /// Frequency happens every month
    /// </summary>
    public static readonly Frequency Monthly = new("MONTHLY");

    /// <summary>
    /// Frequency happens every quarter (every 3 months)
    /// </summary>
    public static readonly Frequency Quarterly = new("QUARTERLY");

    /// <summary>
    /// Frequency happens once a year
    /// </summary>
    public static readonly Frequency Yearly = new("YEARLY");

    /// <summary>
    /// Determines whether the specified object is equal to the current instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns><see langword="true"/> if the specified object is of type <c>Frequency</c> and has the same value as the current
    /// instance; otherwise, <see langword="false"/>.</returns>
    public override bool Equals(object? obj) {
        if (obj == null) {
            return false;
        }

        if (ReferenceEquals(this, obj)) {
            return true;
        }

        if (obj.GetType() != typeof(Frequency)) {
            return false;
        }

        var other = (Frequency)obj;
        return _value == other._value;
    }

    /// <summary>
    /// Defines an implicit conversion from a <see cref="string"/> to a <see cref="Frequency"/> object.
    /// </summary>
    /// <param name="value">The string representation of the frequency.</param>
    public static implicit operator Frequency(string value) {
        return new Frequency(value);
    }

    /// <summary>
    /// Serves as the default hash function for the object.
    /// </summary>
    /// <remarks>This method returns a hash code for the current instance, based on the value of the
    /// underlying field. If the field is <see langword="null"/>, the method returns 0. The hash code is computed using
    /// the <see cref="object.GetHashCode"/> method of the underlying value.</remarks>
    /// <returns>An integer hash code representing the current object.</returns>
    public override int GetHashCode() {
        unchecked { return _value?.GetHashCode() ?? 0; }
    }

    /// <summary>
    /// Returns a string representation of the current object.
    /// </summary>
    /// <returns>The string value of the current object.</returns>
    public override string ToString() {
        return _value;
    }
}