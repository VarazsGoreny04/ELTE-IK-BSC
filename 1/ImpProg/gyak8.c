#include <stdio.h>
#include <stdlib.h>
//#include <string.h>
#include <stdbool.h>

bool is_whitespace(char ch)
{
    return ch ==' ' || ch == '\n' || ch == '\t';
}

void karakterszamlalo()
{
    char buff[1024];
    NULL == fgets(buff, 1024, stdin);
    char prev = ' ';
    int wc = 0;
    int i=0;

    while('\0'!=buff[i])
    {
        if(is_whitespace(prev) && !is_whitespace(buff[i]))
        {
            wc++;
        }
        prev= buff[i];
        i++;
    }
    printf("words:%d\n",wc);
}

// return < 0 -> str1
// return == 0 -> str1 == str2
// return > 0 -> str2

int strcmp(char* str1, char* str2) //#include <string.h>
{
    int i = 0;
    while(str1[i] != '\0' || str2[i] != '\0')
    {
        if(str1[i]!=str2[i])
        {
            //1:a
            //2:b
            return str1[i]-str2[i];           
        }
        i++;
    }
    return str1[i]-str2[i];  
}

void string_compare()
{
    char str1[1024];
    char str2[1024];
    char str3[1024];
    fgets(str1, 1024, stdin);
    fgets(str2, 1024, stdin);

    int res = strcmp(str1, str2);

    printf("%s. string is first\n", res < 0 ? "First" : (res ==0? "Both": "Second"));
    strcpy(str2,str3);
    printf("%s\n",str3);
}

void strcpy(char* source, char* dest) //#include <string.h>
{
    int i=0;
    do{
        dest[i] = source[i];
    }while(source[i++]!= '\0');
}

void capital()
{
    FILE* input = fopen("in.txt", "r");
    FILE* output = fopen("out.txt", "w");
    char buff[1024];

    int num;
    FILE* nums = fopen("nums.txt", "r");
    //fscanf(nums,"%d", $num);

    while(EOF != fscanf(nums, "%d", &num)){
        printf("%d\n", num * num);
        return ;
    }

    while(NULL != fgets(buff, 1024, input))
    {
        for(int i=0; buff[i] != '\0'; i++)
        {
            if(buff[i] >= 'a' && buff[i]<='z'){
                buff[i] -= 'a' - 'A';
            }
        }
        fputs(buff, stdout);
        fputs(buff, output);
        //fprint(output, "%s", buff);
    }
    fclose(input);
    fclose(output);
    fclose(nums);
}
int main()
{
    //karakterszamlalo();
    string_compare();
    capital();
    return 0;
}