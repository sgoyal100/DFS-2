// Time Complexity : O(n)
// Space Complexity : O(h)
// Did this code successfully run on Leetcode : Yes
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach

public string DecodeString(string s) {
        
        if(string.IsNullOrEmpty(s))
            return null;
        
        Stack<StringBuilder> strStack = new Stack<StringBuilder>();
        Stack<int> numStack = new Stack<int>();
        
        int currNum = 0;
        StringBuilder currString = new StringBuilder();
        
        for(int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if(Char.IsDigit(c))
            {                
                currNum = currNum * 10 + (c - '0');
            }
            else if(c == '[')
            {
                numStack.Push(currNum);
                strStack.Push(currString);
                currNum = 0;
                currString = new StringBuilder();
            }
            else if(c == ']')
            {
                int times = numStack.Pop();
                var newStr = new StringBuilder();
                for(int j = 0; j < times; j++)
                {
                    newStr.Append(currString);
                }
                currString = strStack.Pop().Append(newStr);
            }
            else
            {
                
                currString.Append(c);
            }
        }
        return currString.ToString();
    }    
}