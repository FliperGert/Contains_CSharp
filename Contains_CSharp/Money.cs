using System;

namespace Contains_CSharp
{
    public class Money
    {
        private uint _rubles;
        private byte _kopeks;

        public Money(uint rubles = 0, byte kopeks = 0)
        {
            Rubles = rubles;
            Kopeks = kopeks;
        }

        public uint Rubles
        {
            get { return _rubles; }
            set { _rubles = value; }
        }

        public byte Kopeks
        {
            get { return _kopeks; }
            set
            {
                if (value > 99)
                {
                    throw new ArgumentException("Копейки должны быть от 0 до 99");
                }

                _kopeks = value;
            }
        }

        private ulong AllKopeks()
        {
            return (ulong)_rubles * 100 + _kopeks;
        }

        private static Money FromKopeks(ulong allKopeks)
        {
            ulong rubles = allKopeks / 100;

            if (rubles > uint.MaxValue)
            {
                throw new OverflowException("Денежная сумма слишком большая");
            }

            return new Money((uint)rubles, (byte)(allKopeks % 100));
        }


        public static Money operator ++ (Money money)
        {
            return FromKopeks(money.AllKopeks() + 1);
        }

        public static Money operator -- (Money money)
        {
            return money - 1;
        }

        public static explicit operator uint (Money money)
        {
            return money.Rubles;
        }

        public static implicit operator bool (Money money)
        {
            return money.AllKopeks() != 0;
        }

        public static Money operator - (Money money, uint kopeks)
        {
            ulong allKopeks = money.AllKopeks();

            if (kopeks >= allKopeks)
            {
                return new Money();
            }

            return FromKopeks(allKopeks - kopeks);
        }

        public static Money operator - (uint kopeks, Money money)
        {
            return money - kopeks;
        }

        public static Money operator - (Money money1, Money money2)
        {
            ulong allKopeks1 = money1.AllKopeks();
            ulong allKopeks2 = money2.AllKopeks();

            if (allKopeks2 >= allKopeks1)
            {
                return new Money();
            }

            return FromKopeks(allKopeks1 - allKopeks2);
        }

        public override string ToString()
        {
            return $"В наличии {Rubles} руб. и {Kopeks} коп.";
        }
    }
}
