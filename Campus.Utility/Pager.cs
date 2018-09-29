using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Utility
{
    public class Pager
    {
        public static string ShowPageNavigate(int pageSize, int currentPage, int totalCount)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1);
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (currentPage != 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a> ", redirectTo, pageSize);
                }
                if (currentPage > 1)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", redirectTo, currentPage - 1, pageSize);
                }
                else
                {
                   
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage, pageSize, currentPage);
                        }
                        else
                        {
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a> ", redirectTo, currentPage + 1, pageSize);
                }
                else
                {
                    
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a> ", redirectTo, totalPages, pageSize);
                }
                output.Append(" ");
            }
            output.AppendFormat("第{0}页 / 共{1}页", currentPage, totalPages);
            return output.ToString();
        }
    }
}
