using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Added two using statements for PizzaModel
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {

        // Updated OnGet page handler to display list of pizzas from PizzaService
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }

        // Added a List<Pizza> variable named pizzas to the PizzaModel class
        public List<Pizza> pizzas = new();

        // Added this utility method to format the Gluten Free info in the list
        public string GlutenFreeText(Pizza pizza)
        {
            if (pizza.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }

        // Added an HTTP POST page handler to the PageModel class
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        // Added this code to Bind the model 
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        // Added an HTTP POST handler for the delete buttons
        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }

    }
}
