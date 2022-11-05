async function postCustomer(){

    var nev = document.getElementById('nev').value;
    var kor = document.getElementById('kor').value;
    var varos = document.getElementById('varos').value;

    var body = {
        "Eletkor": kor,
        "Nev": nev,
        "Varos": varos
    }

    var url='http://localhost:3000/Service1.svc/CustomerPostDB';
    var putUser=await fetch(url,{
        method: "POST",
        body: body,
        headers: {
            'Content-Type:': 'application/json'
        }
    })
}




async function getCustomers(){

    var url='http://localhost:3000/Service1.svc/CustomerListaDB';
    var userList = await fetch(url);

    if(!userList.ok){
        alert("Végpont hiba!");
        return;
    }

    var users = await userList.json();
    renderUsers(users);

}

function renderUsers(users){
    var contentText='';

    for (const item of users) {
        contentText += `<li>
        <strong>${item.ID}</strong>
        ${item.Nev}
        ${item.Eletkor}
        ${item.Varos}<br>
        </li>`;
    }

    document.getElementById("uList").innerHTML="<ul>"+contentText+"</ul>"
}

getCustomers();