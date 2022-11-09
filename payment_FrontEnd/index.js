document.getElementById('button2').onclick=function (){
    var delNumber=document.getElementById('number2').value;
    delCustomer(delNumber)
}

async function delCustomer(delNumber){
    var url='http://localhost:3000/Service1.svc/CustomerDeleteDB?Id={Id}/'+delNumber;
    var delFetch = await fetch(url,{
        method: "DELETE",
        headers: {
            'content-Type': 'application/json'
        }
    });

    if (!delFetch.ok){
        alert("DELETE végpont hiba!");
        return;
    }

    var httpMessage=await delFetch.json();
    //alert(httpMessage.stringify);
    getCustomers();
}

document.getElementById('form1').onsubmit=function (event){
  
    event.preventDefault();
    var nev=event.target.elements.nev.value;
    var kor=event.target.elements.kor.value;
    var varos=event.target.elements.varos.value;

    var bodyCustomer=JSON.stringify({
      Name: nev,
      Age: kor,
      City: varos
    });

    postCustomer(bodyCustomer);
}

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