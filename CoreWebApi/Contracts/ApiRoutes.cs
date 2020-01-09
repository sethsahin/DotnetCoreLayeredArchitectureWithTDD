namespace CoreWebApi.Contracts
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string BaseUrl = Root +  "/" + Version;
        
        public static class Category
        {
            public const string GetAllCategories = BaseUrl + "/getCategories";
            public const string GetCategoryById = BaseUrl + "/getCategory/{categoryId}";
        }

        public static class Auth
        {
            public const string Register = BaseUrl + "/auth/register";
            public const string Login = BaseUrl + "/auth/login";
        }
    }
}