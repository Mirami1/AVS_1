using System;

namespace AVS_1
{
    public class ip
    {
        public string name, status;
        public uint value;
        public byte[] ipvalues;

        public ip()
        {
            value = 0;
            status = "";
        }

        public ip(uint _value)
        {
            value = _value;
            name = status = "";
            ipvalues=new byte[4];
            for (int i = 0; i < 4; ++i) // сдвигаем влево-вправо эти несчастные 8 бит
            {
                ipvalues[i] = ((byte) ((value << (8 * i)) >> (8 * 3)));
            }
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < 4; ++i)
            {
                s += ipvalues[i].ToString();
                if (i != 3) s += '.';
            }
            return s;
        }
        public uint Mask(uint target)
        {
            uint rez = 0;
            for (int i = 31; i >= 0; --i)
            {
                if (target >> i == value >> i) rez += (uint)Math.Pow(2, i);
                else break;
            }
            return rez;
        }

        public uint Adress(uint mask)
        {
            return mask & value;
        }

        public uint Broadcast(uint mask)
        {
            return ~mask | value;
        }
    }
}