using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Olá!");
app.MapPost("/", () => new {Name = "Bernardo Druziki", age = 18});
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Teste", "Bernardo Druziki");
    return new {Name = "Bernardo Druziki", age = 18};
});

app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

//api.app.com/users?datastart={}&dateend={date}
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});
//api.app.com/users/{code}
app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
    return code;
});

app.MapGet("/getproductbyheader", (HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});

app.Run();

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}