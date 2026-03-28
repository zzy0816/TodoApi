//Program.cs / Zhang Zhenyu / 2026-02-26  
//
// 应用程序入口：配置 WebApplication 与依赖注入容器

using TodoApi.Services;
using TodoApi.Config;

// 创建 WebApplication 构建器，用于配置服务与中间件
var builder = WebApplication.CreateBuilder(args);

// 注册控制器相关服务（启用基于控制器的 API）
builder.Services.AddControllers();

// 注册待办事项业务服务到 DI 容器（每次请求创建一个实例）
builder.Services.AddSingleton<ITodoService, TodoService>();

// 绑定配置文件中的 "TodoSettings" 节点到 TodoSettings 配置对象
builder.Services.Configure<TodoSettings>(
    builder.Configuration.GetSection("TodoSettings"));

// 构建应用程序实例
var app = builder.Build();

// 仅在开发环境暴露 OpenAPI/Swagger 端点，方便调试与文档查看
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// 强制使用 HTTPS 重定向，提高通信安全性
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// 根据路由自动映射控制器中的路由与处理程序
app.MapControllers();

// 启动 Web 应用并开始监听请求
app.Run();

