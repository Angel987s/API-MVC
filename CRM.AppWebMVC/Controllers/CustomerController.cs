using CRM.DTOs.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CRM.AppWebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClientCRMAPI;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRMAPI = httpClientFactory.CreateClient("CRMAPI");
        }

        public async Task<IActionResult> Index(SearchQueryCustomerDTO searchQueryCustomerDTO, int CountRow = 0)
        {
            if (searchQueryCustomerDTO.SendRowCount == 0)
                searchQueryCustomerDTO.SendRowCount = 2;

            if (searchQueryCustomerDTO.Take == 0)
                searchQueryCustomerDTO.Take = 10;

            var result = new SearchResultCustomerDTO();

           
                var response = await _httpClientCRMAPI.PostAsJsonAsync("/customer/search", searchQueryCustomerDTO);

                if (response.IsSuccessStatusCode) 
                    result = await response.Content.ReadFromJsonAsync<SearchResultCustomerDTO>();
                

                result = result != null ? result : new SearchResultCustomerDTO();

                if (result.CountRow == 0 && searchQueryCustomerDTO.SendRowCount == 1)
                    result.CountRow = CountRow;

                    ViewBag.CountRow = result.CountRow;
                    searchQueryCustomerDTO.SendRowCount = 0;
                ViewBag.SearchQuery = searchQueryCustomerDTO;

                return View(result);
           
        }


        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest("ID inválido");

            var result = new GetIdResultCustomerDTO();

            try
            {
                var response = await _httpClientCRMAPI.GetAsync($"/customer/{id}");

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();
                }

                return View(result ?? new GetIdResultCustomerDTO());
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al obtener los detalles: {ex.Message}";
                return View(new GetIdResultCustomerDTO());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerDTO createCustomerDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(createCustomerDTO);
            }

            try
            {
                var response = await _httpClientCRMAPI.PostAsJsonAsync("/customer", createCustomerDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar guardar el registro";
                return View(createCustomerDTO);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(createCustomerDTO);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return BadRequest("ID inválido");

            var result = new GetIdResultCustomerDTO();

            try
            {
                var response = await _httpClientCRMAPI.GetAsync($"/customer/{id}");

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();
                }

                return View(new EditCustomerDTO(result ?? new GetIdResultCustomerDTO()));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al obtener los detalles para edición: {ex.Message}";
                return View(new EditCustomerDTO());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCustomerDTO editCustomerDTO)
        {
            if (id <= 0) return BadRequest("ID inválido");

            try
            {
                var response = await _httpClientCRMAPI.PutAsJsonAsync("/customer", editCustomerDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar editar el registro";
                return View(editCustomerDTO);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(editCustomerDTO);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("ID inválido");

            var result = new GetIdResultCustomerDTO();

            try
            {
                var response = await _httpClientCRMAPI.GetAsync($"/customer/{id}");

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();
                }

                return View(result ?? new GetIdResultCustomerDTO());
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al obtener el registro para eliminar: {ex.Message}";
                return View(new GetIdResultCustomerDTO());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultCustomerDTO getIdResultCustomerDTO)
        {
            if (id <= 0) return BadRequest("ID inválido");

            try
            {
                var response = await _httpClientCRMAPI.DeleteAsync($"/customer/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar eliminar el registro";
                return View(getIdResultCustomerDTO);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(getIdResultCustomerDTO);
            }
        }
    }
}
