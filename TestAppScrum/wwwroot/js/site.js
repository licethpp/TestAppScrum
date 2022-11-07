
$(document).ready(function () {

    if (document.getElementById('lijstArtikelen') != null)
        $('#lijstArtikelen').DataTable
            ({
                "lengthMenu": [[5, 10, 20 - 1], [5, 10, 20, "Alle"]],
                "pageLength": 5
            });
});


$(document).ready(function () {

    if (document.getElementById('Categorieen') != null)
        $('#Categorieen').DataTable
            ({
                "lengthMenu": [[5, 10, 20 - 1], [5, 10, 20, "Alle"]],
                "pageLength": 5
            });
});

Categorieen
const navTabs = document.querySelectorAll("#nav-tabs > a");
navTabs.forEach((tab) => {
    tab.addEventListener("click", () => {
        navTabs.forEach((tab) => {
            tab.classList.remove("active");
        });
        tab.classList.add("active");
    });
});


var working = false;
$('.login').on('submit', function (e) {
    e.preventDefault();
    if (working) return;
    working = true;
    var $this = $(this),
        $state = $this.find('button > .state');
    $this.addClass('loading');
    $state.html('Authenticating');
    setTimeout(function () {
        $this.addClass('ok');
        $state.html('Welcome back!');
        setTimeout(function () {
            $state.html('Log in');
            $this.removeClass('ok loading');
            working = false;
        }, 4000);
    }, 3000);
});
