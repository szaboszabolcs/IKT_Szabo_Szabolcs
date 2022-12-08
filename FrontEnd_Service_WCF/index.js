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
    deletUser(id);
}

async function deletUser(id){
    var url='http://localhost:5001/Service1.svc/UserDeleteDB?Id='+id;
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
async function getUsers(){

    var url='http://localhost:5001/Service1.svc/UserListaDB';
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
        contentText += 
        `<table style="border: 1px solid;  border-collapse: collapse; text-align: center; ">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Uname</th>
                    <th>Email</th>
                    <th>Password</th>
                    <th>Fullname</th>
                    <th>Active</th>
                    <th>Rank</th>
                    <th>Ban</th>
                    <th>Reg_Time</th>
                    <th>Log_Time</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>${item.ID}</td>
                    <td>${item.Uname}</td>
                    <td>${item.Email}</td>
                    <td>${item.Password}</td>
                    <td>${item.Fullname}</td>
                    <td>${item.Active}</td>
                    <td>${item.Rank}</td>
                    <td>${item.Banned}</td>
                    <td>${item.Reg_Time}</td>
                    <td>${item.Log_Time}</td>
                   
                </tr>
            </tbody>
        </table>`;
    }

    document.getElementById("uList").innerHTML="<table>"+contentText+"</table>"
}

getUsers();