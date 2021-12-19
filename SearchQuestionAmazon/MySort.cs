using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchQuestionAmazon
{
    public class MySort
    {
        public static string FastSort(List<int> data)
        {
            data = FastSorthelper(0,data.Count-1,data);

            string sort = string.Empty;
            for (int i = 0; i<data.Count; i++)
            {
                sort +=data[i] +",";
            }

            return sort;
        }

        private static List<int> FastSorthelper(int leftindex,int rightindex, List<int> data)
        {
            int keyvalueposition = 0;
            if(leftindex<rightindex)
            {
                keyvalueposition = FindKeyvaluePosition(leftindex,rightindex,data);

                FastSorthelper(leftindex, keyvalueposition-1, data);
                FastSorthelper(keyvalueposition+1,rightindex,data);
            }

            return data;
        }

        private static int FindKeyvaluePosition(int leftindex, int rightindex, List<int> data)
        {
            int keyvalue = data[leftindex];

            while (leftindex<rightindex)
            {
                while (leftindex< rightindex && data[leftindex] < keyvalue)
                    leftindex++;
                while (leftindex<rightindex && data[rightindex] > keyvalue)
                    rightindex--;

                //switch left data and right data
                int temp = data[leftindex];
                data[leftindex] = data[rightindex];
                data[rightindex] = temp;
            }

            if(keyvalue < data[rightindex])
            {//switch keyvalue and data[rightindex -1]
                data[leftindex] = data[rightindex-1];
                data[rightindex]= keyvalue;
                return rightindex-1;
            }
            else
            {//switch keyvalue and data[rightindex]
                data[leftindex] = data[rightindex];
                data[rightindex]= keyvalue;
                return rightindex;
            }

        }

        public static string BubbleSort(List<int> data)
        {//O(n2)
            for(int i=0;i<data.Count;i++)
            {
                for(int j=i;j<data.Count;j++)
                {
                    if(data[i]>data[j])
                    {
                        int temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
                }
            }

            string sort = string.Empty;
            for(int i=0;i<data.Count;i++)
            {
                sort +=data[i] +",";
            }

            return sort;
        }


    }
}
