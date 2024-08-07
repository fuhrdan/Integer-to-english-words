//*****************************************************************************
//** 273. Integer to English Words  leetcode                                 **
//** I used case statements, which was very slow but it worked  -Dan         **
//*****************************************************************************

const char *below_20[] = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                          "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen",     "Nineteen"};
const char *tens[] = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
const char *thousands[] = {"hundred", "Thousand", "Million", "Billion"};

char* numberToWords(int num) {
    if(num==0) return "Zero";
    char temp[256] = {0};
    char output[1024] = {""};
    char mix[1024][1024] = {""};
    int new = num;
    int newTeens = 0;
    int position = 0;
    int tensnum = 0;
    int number = 0;
    int thousandswitch = 0;
    while(new > 0)
    {
        int single = new % 10;
        new = (new - single) / 10;
        position++;
//        printf("New = %d\n",new);
        if((position==2)||(position==5)||(position==8)||(position==11)) tensnum = 1;
        if((position==1)||(position==4)||(position==7)||(position==10))
        {
            newTeens = new % 10;
            if(newTeens == 1) 
            {
                int newsingle = (newTeens * 10) + single;
//                printf("Single = %d\n",newsingle);
                new = (((new*10)+single) - newsingle) / 10;
                single = newsingle;
//                printf("New new = %d\n",new);
            }
        } 
//        printf("Position == %d and single = %d and new = %d\n",position,single,new);
        if(((position==3)&&(single>0))||((position==6)&&(single>0))||((position==9)&&(single>0))||((position==12)&&(single>0)))
        {
            strcat(mix[number++], "Hundred");
        }
        else if(position==4)
        {
            int single2 = new % 10;
            int single3 = new % 100;
//            printf("single = %d, single2 = %d, single3 = %d\n",single,single2,single3);
            if((single > 0)||(single2 > 0)||(single3 > 0))
                strcat(mix[number++],"Thousand");
        }
//        else if((position==6)&&(single>0))
//        { 
//            strcat(mix[number++],"Hundred");
//        }
        else if(position==7)
        {
            int single2 = new % 10;
            int single3 = new % 100;
            if((single > 0)||(single2 > 0)||(single3 > 0))
            strcat(mix[number++],"Million");
        }
        else if(position==10)
        {
            strcat(mix[number++],"Billion");
        }
        else if(position==13)
        {
            strcat(mix[number++],"Trillion");
        }
    
        switch(single)
        {
            case 1: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Ten");
                }
                else
                {
                    strcat(mix[number++], "One");
                }
                break;
            case 2: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Twenty");
                }
                else
                {
                    strcat(mix[number++], "Two");
                }
                break;
            case 3: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Thirty");
                }
                else
                {
                    strcat(mix[number++], "Three");
                }
                break;
            case 4: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Forty");
                }
                else
                {
                    strcat(mix[number++], "Four");
                }
                break;
            case 5: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Fifty");
                }
                else
                {
                    strcat(mix[number++], "Five");
                }
                break;
            case 6: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Sixty");
                }
                else
                {
                    strcat(mix[number++], "Six");
                }
                break;
            case 7: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Seventy");
                }
                else
                {
                    strcat(mix[number++], "Seven");
                }
                break;
            case 8: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Eighty");
                }
                else
                {
                    strcat(mix[number++], "Eight");
                }
                break;
            case 9: 
                if(tensnum==1)
                {
                    strcat(mix[number++], "Ninety");
                }
                else
                {
                    strcat(mix[number++], "Nine");
                }
                break;
            case 10:
                strcat(mix[number++],below_20[single]);
                break;
            case 11:
                strcat(mix[number++],below_20[single]);
                break;
            case 12:
                strcat(mix[number++],below_20[single]);
                break;
            case 13:
                strcat(mix[number++],below_20[single]);
                break;
            case 14:
                strcat(mix[number++],below_20[single]);
                break;
            case 15:
                strcat(mix[number++],below_20[single]);
                break;
            case 16:
                strcat(mix[number++],below_20[single]);
                break;
            case 17:
                strcat(mix[number++],below_20[single]);
                break;
            case 18:
                strcat(mix[number++],below_20[single]);
                break;
            case 19:
                strcat(mix[number++],below_20[single]);
                break;
        }
        tensnum = 0;
    }
//    printf("Final Number = %d\n",number);
    for(int i = (number-1); i >= 0; i--)
    {
//        printf("Mix[%d] = %s\n",i,mix[i]);
        strcat(output,mix[i]);
        if(i==0) {}
        else 
        {
            if(mix[i-1])
                strcat(output," ");
        }
    }
    char* result = (char *)malloc((strlen(output) + 1) * sizeof(char));
    strcpy(result,output);
    return result;
}