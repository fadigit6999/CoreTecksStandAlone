$(document).ready(function () {
    //Click button to get partial view from views to getemployee modal
    $("#registerEmployee").click(function () {
        //ASP.NET Core MVC Controller using AJAX
        $.ajax({
            type: "GET",
            url: "/Home/CreateEmployee",  // Change to your actual controller method
            success: function (response) {
                $("#employeeModalForm").html(response);//getting partial view form of employee
                IntializeEmployee();

            },
            error: function () {
                alert("Error saving employee.");
            }
        });
    });
    
})


function IntializeEmployee() {
    $("#submitEmployee").click(function (e) {
       /* debugger;*/
        var formData = {
            Name: $("input[name='Name']").val(),
            Phone: $("input[name='Phone']").val(),
            Address: $("input[name='Address']").val(),
            Salary: $("input[name='Salary']").val() // Include AntiForgery Token
        };

        $.ajax({
            type: "POST",
            url: "/Home/CreateEmployee",  // Ensure this matches your controller route
            contentType: "application/json",
            data: JSON.stringify(formData),  // Convert to JSON string
            success: function (response) {
                if (response.success) {
                    $("#Employeeform")[0].reset(); // Reset form fields
                    //load employees list
                }
            },
            error: function () {
                alert("An error occurred while saving the employee.");
            }
        });

    });
}