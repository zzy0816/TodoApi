Todo API - 极简待办事项服务
一个使用 ASP.NET Core 构建的极简待办事项 API，用于学习和演示 .NET 后端开发的核心概念：异步编程、依赖注入、配置选项和 RESTful API 设计。

✨ 功能特性
创建待办事项

查看所有待办事项

查看单个待办事项详情

更新待办事项完成状态

删除待办事项（可配置开关）

内存存储（重启后数据丢失，仅用于演示）

🛠️ 技术栈
.NET 10 / ASP.NET Core

原生依赖注入（DI）

异步编程（async/await）

选项模式读取配置

Swagger/OpenAPI 文档

🚀 如何运行
克隆或下载本项目

在项目根目录打开终端

运行以下命令

bash
dotnet run
打开浏览器访问

text
https://localhost:5258/swagger
即可看到 Swagger UI，测试所有 API 端点。

📁 项目结构
text
TodoApi/
├── Controllers/          # API 控制器
│   └── TodoController.cs
├── Models/               # 数据实体
│   └── TodoItem.cs
├── Services/             # 业务逻辑接口和实现
│   ├── ITodoService.cs
│   └── TodoService.cs
├── Config/               # 配置类
│   └── TodoSettings.cs
├── appsettings.json      # 配置文件
└── Program.cs            # 应用入口和依赖注册

📚 API 端点
方法	路径	描述	请求体/参数
GET	/api/todo	获取所有待办事项	无
GET	/api/todo/{id}	获取单个待办事项	id (路径参数)
POST	/api/todo?title=...	创建新待办事项	title (查询参数)
PUT	/api/todo/{id}?isCompleted=...	更新完成状态	id, isCompleted (查询参数)
DELETE	/api/todo/{id}	删除待办事项	id (路径参数)

⚙️ 配置说明
在 appsettings.json 中可以调整以下行为：

json
"TodoSettings": {
  "MaxTitleLength": 100,    // 标题最大长度
  "AllowDelete": true        // 是否允许删除操作
}

📖 学习要点
本项目涵盖了 .NET 后端开发的几个核心概念：

异步编程：所有 Service 方法返回 Task，Controller 使用 async/await 处理异步操作。

依赖注入：通过构造函数注入 ITodoService 和 IOptions<TodoSettings>，实现松耦合。

选项模式：使用强类型配置类读取 appsettings.json，并在 Controller 中注入使用。

RESTful 设计：遵循 HTTP 语义，返回适当的状态码（200, 201, 204, 400, 404 等）。

添加日志记录（ILogger<T>）

📝 后续扩展建议
Swagger 集成：自动生成 API 文档，方便测试。

接入真实数据库（如 SQLite、Entity Framework Core）AddSingleton -> AddScoped

实现用户认证和授权

编写单元测试
