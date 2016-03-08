function addrow(a) {
    if (a == 1)
        document.getElementById("idaddtabela").style.display = "block",
        document.getElementById("botaologin").innerHTML = "<i class='material-icons' onclick='addrow(0)'>vpn_key</i>",
        document.getElementById("tabelabotoes").style.display = "none";
    else
        document.getElementById("botaologin").innerHTML = "<i class='material-icons' onclick='addrow(1)'>vpn_key</i>",
        document.getElementById("idaddtabela").style.display = "none",
        document.getElementById("tabelabotoes").style.display = "block";
}