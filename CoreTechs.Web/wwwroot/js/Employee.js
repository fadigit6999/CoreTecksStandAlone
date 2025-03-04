$(document).ready(function() {
    $("#registerEmployee").click(function () {
        // Send data to ASP.NET Core MVC Controller using AJAX
        $.ajax({
            type: "GET",
            url: "/Home/CreateEmployee",  // Change to your actual controller method
            success: function (response) {
                $("#employeeModalForm").html(response);
            },
            error: function () {
                alert("Error saving employee.");
            }
        });
    });


    $("#submitEmployee").click(function (e) {
        debugger;
        var formData = {
            Name: $("input[name='Name']").val(),
            Phone: $("input[name='Phone']").val(),
            Address: $("input[name='Address']").val(),
            Salary: $("input[name='Salary']").val(),
            __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val() // Include AntiForgery Token
        };

        $.ajax({
            type: "POST",
            url: "/Employee/CreateEmployee",  // Ensure this matches your controller route
            data: formData,
            success: function (response) {
                if (response.success) {
                    alert(response.message); // Show success message
                    $("#Employeeform")[0].reset(); // Reset form fields
                    window.location.href = "/Home/GetEmployee/1"; // Redirect to Employee List
                } else {
                    alert(response.message); // Show error message
                    console.log(response.errors); // Debug validation errors
                }
            },
            error: function () {
                alert("An error occurred while saving the employee.");
            }
        });

    });
})


