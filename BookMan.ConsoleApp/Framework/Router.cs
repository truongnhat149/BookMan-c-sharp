using System;
namespace Framework
{
    public class Router
    {
        /// <summary>
        /// lớp xử lý truy vấn
        /// </summary>
        private class Request
        {
            /// <summary>
            /// thành phần lệnh của truy vấn
            /// </summary>
            public string Route { get; private set; }
            /// <summary>
            /// thành phần tham số của truy vấn
            /// </summary>
            public Parameter Parameter { get; private set; }
            public Request(string request)
            {
                Analyze(request);
            }
            /// <summary>
            /// phân tích truy vấn để tách ra thành phần lệnh và thành phần tham số
            /// </summary>
            /// <param name="request"></param>
            private void Analyze(string request)
            {
                // tìm xem trong chuỗi truy vấn có tham số hay không
                var firstIndex = request.IndexOf('?');
                // trườn hợp truy vấn không chứa tham số
                if (firstIndex < 0)
                {
                    Route = request.ToLower().Trim();
                }
                // trường hợp truy vấn chứa tham số
                else
                {
                    // nếu chuỗi lối (chỉ chứa tham số, không chứa route)
                    if (firstIndex <= 1) throw new Exception("Invalid request parameter");
                    // cắt chuỗi truy vấn lấy mốc là ký tự ?
                    // sau phép toán này thu được mảng 2 phần tử: thứ nhất là route, thứ hai là chuỗi parameter
                    var tokens = request.Split(new[] { '?' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    // route là thành phần lệnh của truy vấn
                    Route = tokens[0].Trim().ToLower();
                    // parameter là thành phần tham số của truy vấn
                    var parameterPart = request.Substring(firstIndex + 1).Trim();
                    Parameter = new Parameter(parameterPart);
                }
            }
        }
    }
}