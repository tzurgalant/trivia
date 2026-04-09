#include "Communicator.h"
#include "LoginRequestHandler.h"


Communicator::Communicator()
{

	// this server use TCP. that why SOCK_STREAM & IPPROTO_TCP
	// if the server use UDP we will use: SOCK_DGRAM & IPPROTO_UDP
	m_serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (m_serverSocket == INVALID_SOCKET)
		throw std::exception(__FUNCTION__ " - socket");
}
Communicator::~Communicator()
{
	try
	{
		// the only use of the destructor should be for freeing 
		// resources that was allocated in the constructor
		closesocket(m_serverSocket);
	}
	catch (...) {}
}
void Communicator::startHandleRequest()
{
	bindAndLsiten();
	while (true)
	{
		// this accepts the client and create a specific socket from server to this client
		// the process will not continue until a client connects to the server
		SOCKET clientSocket = accept(m_serverSocket, NULL, NULL);
		if (clientSocket == INVALID_SOCKET)
			throw std::exception(__FUNCTION__);

		std::cout << "Client accepted. Server and client can speak" << std::endl;
		//now we create a thread for each clients and pass the clientHandler fucniton as thread

		m_clients[clientSocket] = new LoginRequestHandler();
		std::thread clientThread(&Communicator::handleNewClient, this, clientSocket);
		clientThread.detach();
	}
}


void Communicator::bindAndLsiten() const 
{
	struct sockaddr_in sa = { 0 };

	sa.sin_port = htons(PORT); // port that server will listen for
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;    // when there are few ip's for the machine. We will use always "INADDR_ANY"

	// Connects between the socket and the configuration (port and etc..)
	if (bind(m_serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		std::cout << "error in __FUNCTION__  - bind" << std::endl;

	// Start listening for incoming requests of clients
	if (listen(m_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		std::cout << "error in __FUNCTION__  - listen" << std::endl;
	std::cout << "Listening on port " << PORT << std::endl;

}

void Communicator::handleNewClient(SOCKET userS)
{
	try
	{
		//send hello message
		std::string helloMes = "Hello\n";
		send(userS, helloMes.c_str(), (int)helloMes.size(), 0);

		while (true)
		{
			char buffer[1024];
			// get message
			int res = recv(userS, buffer, 1023, 0);

			if (res < 1) // if not success to get fucntoin throw a exception
			{
				throw std::exception("Error while receiving from socket");
			}
			// res == how mauch bytes redings so in the of them we put \0
			buffer[res] = '\0';

			std::cout << "Received from socket " << userS << ": " << buffer << std::endl;

			//return the user what he send
			if (send(userS, buffer, res, 0) == SOCKET_ERROR)
			{
				throw std::exception("Error while sending message to client");
			}
		}
	}
	catch (const std::exception& e) {
		std::cout << "Exception in clientHandler: " << e.what() << std::endl;
	}

	closeClient(userS);
}
void Communicator::closeClient(SOCKET userS)
{
	if (m_clients.count(userS)) { //check if the user exist
		delete m_clients[userS];/// neeed to clean we alcate a mameroy for the iReuestHandler....

		m_clients.erase(userS);// delete the user form the 
		std::cout << "Socket " << userS << " removed from map." << std::endl;
		closesocket(userS);
	}
}

void Communicator::closeAllClients()
{
	for (auto const& clientData : m_clients)
	{
		SOCKET userS = clientData.first;            
		closeClient(userS);
	}
}
