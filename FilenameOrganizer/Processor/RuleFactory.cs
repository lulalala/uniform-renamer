namespace FilenameOrganizer.Processor
{
    using System;
    using System.IO;

    static class RuleFactory
    {
        public static RuleList ParseRule(string text)
        {
            StringReader sr = new StringReader(text);
            RuleList rules = null;
            string[] tokens;
            string s;

            while (true)
            {
                s = sr.ReadLine();

                if (s != null)
                {
                    // comment & empty lines
                    if (s.StartsWith("//") || s.Length == 0)
                    {
                        ;
                    }
                    // format string
                    else if (rules==null)
                    {
                        rules = new RuleList(s);
                    }
                    // rule
                    else
                    {
                        tokens = s.Split('\t');
                        if (tokens[0].StartsWith("reg_"))
                        //Regular Expression Rule
                        {
                            rules.Add(new RegexRule(tokens[0], tokens[1]));
                        }
                        else if(tokens[0].Equals("delete"))
                        //Delete Rule
                        {
                            if(tokens.Length == 1)
                                throw new System.ArgumentException("Delete rule empty");
                            rules.Add(new DeleteRule(new ArraySegment<string>(tokens, 1, tokens.Length - 1).Array));
                        }
                        else
                        //Replace Rule
                        {
                            if (tokens.Length < 3)
                                throw new System.ArgumentException("Replace rules need to have at least 3 items delimited by tabs");
                            string[] targets = new string[tokens.Length -2];
                            Array.Copy(tokens, 2, targets, 0, targets.Length);
                            rules.Add(new ReplaceRule(tokens[0], tokens[1], targets));
                        }
                    }
                }
                else
                    break;
            }

            return rules;
        }
    }
}