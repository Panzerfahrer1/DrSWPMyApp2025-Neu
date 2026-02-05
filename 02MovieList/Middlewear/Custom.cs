namespace _02MovieList.Middlewear
{
    public class Custom
    {
        private readonly RequestDelegate _next;

        public Custom(RequestDelegate @delegate)
        {
            // Function pointer auf die nächste Middlewear
            // Diese wird im Programm.cs automatisch gemacht.
            // zb app.UseStaticFiles ist das nächste => _next zeigt auf UseStaticFiles
            _next = @delegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // add request code here

            Console.WriteLine("Custom Middlewear ....");
            // er wartet auf die Antwort der nächsten middlewear
            // □ (hier sind wir) => □ (M2) => □(M3) => □ (M4); Nach M4 ist er fertig und geht wieder zurück
            // □ (hier sind wir) <= □ (M2) <= □(M3) <= □ (M4); Wenn er wieder bei unserer Middlewear ist, ist await vorbei
            await _next(context);
            // add response code here

            Console.WriteLine("CM Middlewear Response.......");
        }
    }
}
