# C# projektni zadaci

## Klijent-Server web socket

Ovaj projekat kreira dve klase - klijenta i servera koji se međusobno povezuju pomoću socketa. Za razmenu se koristi "izmišljeni" protokol, odnosno klijent salje zahtev odredjenog tipa (A-G) i server na osnovu tipa odgvara sa različitim informacijama.

Projekat je uradjen kao domaći na nekom univerzitetu u Sloveniji.

### Prikaz:
<img style="min-width: 600px" src="./Klijent-Server web socket/Screenshots/server-start.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - startup<i></p>
<img style="min-width: 600px" src="./Klijent-Server web socket/Screenshots/client-start.PNG" />
<p style="text-align:center; max-width: 600px;"><i>client - startup<i></p>
<img style="min-width: 600px" src="./Klijent-Server web socket/Screenshots/server-client connected.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - new client connected<i></p>
<img style="min-width: 600px" src="./Klijent-Server web socket/Screenshots/client A.PNG" />
<p style="text-align:center; max-width: 600px;"><i>client - send type A request<i></p>
<img style="min-width: 600px" src="./Klijent-Server web socket/Screenshots/server A.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - respond to type A request<i></p>
<img style="min-width: 600px" src="./Klijent-Server web socket/Screenshots/client G.PNG" />
<p style="text-align:center; max-width: 600px;"><i>client - send type G request<i></p>
<img style="min-width: 600px" src="./Klijent-Server web socket/Screenshots/server G.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - respond to type G request<i></p>

## Peer2Peer Network

Ovaj projekat kreira peer to peer mrežu koja omogućava slanje poruka u mreži. Postoji Discovery Server koji čuva sve trenutno povezane uređaje i svaki klijent pri povezivanju u mrežu traži od servera adrese svih čvorova sa kojim se potom povezuje. Peer uređaji podržavaju onNewNodeConnect, onNodeDisconnect i onMessage događaje.

### Prikaz

<img style="min-width: 600px" src="./Peer-To-Peer Network With Discovery Server/screenshots/server start.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - startup<i></p>
<img style="min-width: 600px" src="./Peer-To-Peer Network With Discovery Server/screenshots/server logs.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - logs<i></p>
<img style="min-width: 600px" src="./Peer-To-Peer Network With Discovery Server/screenshots/peer - onconnect.PNG" />
<p style="text-align:center; max-width: 600px;"><i>peer - new node connected <i></p>
<img style="min-width: 600px" src="./Peer-To-Peer Network With Discovery Server/screenshots/peer - send a message.PNG" />
<p style="text-align:center; max-width: 600px;"><i>peer - send a message<i></p>
<img style="min-width: 600px" src="./Peer-To-Peer Network With Discovery Server/screenshots/peers - onmessage.PNG" />
<p style="text-align:center; max-width: 600px;"><i>peer - message recieved<i></p>
<img style="min-width: 600px" src="./Peer-To-Peer Network With Discovery Server/screenshots/peer - ondisconnect.PNG" />
<p style="text-align:center; max-width: 600px;"><i>peer - node diconnected<i></p>

## Blockchain

Koristi peer to peer mrežu da omogući kreiranje novih blokova u chain. Koristi mining i proof of work.

Projekat napravljen kao domaći na nekom univerzitetu u Sloveniji.

### Prikaz


<img style="min-width: 600px" src="./Blockchain/screenshots/server start.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - startup<i></p>
<img style="min-width: 600px" src="./Blockchain/screenshots/server logs.PNG" />
<p style="text-align:center; max-width: 600px;"><i>server - logs<i></p>
<img style="min-width: 600px" src="./Blockchain/screenshots/app - blockchain tab.PNG" />
<p style="text-align:center; max-width: 600px;"><i>app - blockchain tab<i></p>
<img style="min-width: 600px" src="./Blockchain/screenshots/app - network tab.PNG" />
<p style="text-align:center; max-width: 600px;"><i>app - network tab<i></p>
<img style="min-width: 600px" src="./Blockchain/screenshots/app - logs.PNG" />
<p style="text-align:center; max-width: 600px;"><i>app - logs tab<i></p>
<img style="min-width: 600px" src="./Blockchain/screenshots/block details.PNG" />
<p style="text-align:center; max-width: 600px;"><i>block details form<i></p>

## Sat

Projekat iscrtava sat u Windows Formi. Sat je responzivan i uvek je pravilan krug, bez obzira na dimenzije prozora. Koristi trigonometrijske funkcije za preračunavanje pozicija kazaljki i brojeva.

Projekat je nastao kao vežba o grafici i tajmerima u C# za predmet programiranje u 3. razredu srednje škole.


<img style="min-width: 600px" src="./SAT/screenshots/sat.PNG" />
<p style="text-align:center; max-width: 600px;"><i>sat<i></p>

### Prikaz


## Zmijice

Omogućava igranje zmijica u Windows Form Aplikaciji. Zmijica se pomeranjem korišćenjem UP, DOWN, LEFT i RIGHT ARROW dugmića, a space pauzira igru.

Projekat je nastao kao vežba o grafici i key eventima u C# za predmer programiranje u 3. razredu srednje škole.

## Prikaz

<img style="min-width: 600px" src="./Zmijice/screenshots/igra.PNG" />
<p style="text-align:center; max-width: 600px;"><i>igra<i></p>
<img style="min-width: 600px" src="./Zmijice/screenshots/meni.PNG" />
<p style="text-align:center; max-width: 600px;"><i>kraj igre i meni<i></p>



