var state = false;

document.getElementById("state").onclick = function (){

    if(state){
        state =! state;
        document.getElementById('idField').innerHTML = "";
    }
    else{
        state = !state;
        var contentText=`
        ID: <input type='number' id='idNumber'><br>
        `;
        document.getElementById('idField').innerHTML = contentText;
    }
}

document.getElementById('button2').onclick =  function(){
    id = document.getElementById('number2').value;
    deletCustomer(id);
}

async function deletCustomer(id){
    var url='http://localhost:3000/Service1.svc/CustomerDeleteDB?Id='+id;
    var delUser = await fetch(url,{
        method: "DELETE",
        headers: {
            'Content-type': 'application/json'
        }
    });

    if(!delUser.ok){
        alert("Delete hiba!");
        return;
    }

    var httpMessage = await delUser.json();

    alert(httpMessage);

    getCustomers();
}

document.getElementById('forms').onsubmit=function (event){
  
    event.preventDefault();

    var nev=event.target.elements.nev.value;
    var kor=event.target.elements.kor.value;
    var varos=event.target.elements.varos.value;

    if(!state){
        var bodyCustomer=JSON.stringify({
            Eletkor: kor,
            Nev: nev,
            Varos: varos
          });

        postCustomer(bodyCustomer);
        
    }
    else{
        var id=event.target.elements.idNumber.value;

        var bodyCustomer=JSON.stringify({
            ID: id,
            Nev: nev,
            Eletkor: kor,
            Varos: varos
          });

    
        updateCustomer(bodyCustomer);
        
    }
}

//POST Hozzáadás //
async function postCustomer(bodyCustomer){
   
    var url='http://localhost:3000/Service1.svc/CustomerPostDB';
    
    var postUser=await fetch(url,{
        method: "POST",
        body: bodyCustomer,
        headers: {
            'Content-Type': 'application/json'
        }
    })

    if(!postUser.ok){
        alert("POST végpont hiba!");
        return;
    }

    var httpMessage=await postUser.json();

    alert(httpMessage);

    getCustomers();
} 

//UPDATE módosítás //
async function updateCustomer(bodyCustomer){
    var url='http://localhost:3000/Service1.svc/CustomerPutDB/'
    var upUser=await fetch(url,{
        method: "POST",
        body:bodyCustomer,
        headers:{
            'Content-type':'application/json'
        }
    });

    if(!upUser.ok)
    {
        alert("Update hiba!")
        return;
    }

    var upResult=await upUser.json();

    alert(upResult);

    getCustomers();
}


// GET lekérés //
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