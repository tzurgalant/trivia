#include "Communicator.h"
#include "LoginRequestHandler.h"
#include <typeinfo>
Communicator::Communicator(RequestHandlerFactory& handleFactory):m_handleFactory(handleFactory)
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

		m_clients[clientSocket] = m_handleFactory.createLoginRequestHandler();
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
bool receiveAll(int socket, char* buffer, size_t size) {
	size_t totalReceived = 0;//read [size] of data from the socket and wait to the recve to get all the data that needed
	while (totalReceived < size) {
		int bytes = recv(socket, buffer + totalReceived, size - totalReceived, 0);
		if (bytes <= 0) return false; //retu rn false if there error on the clihnet disconnect
		totalReceived += bytes;
	}
	return true;
}
bool sendAll(int socket, const char* buffer, size_t size) {// like receive all but oppside
	size_t totalSent = 0;

	while (totalSent < size) {
		int bytes = send(socket, buffer + totalSent, size - totalSent, 0);

		if (bytes == -1) {
			return false;
		}

		totalSent += bytes;
	}

	return true;
}

void Communicator::handleNewClient(SOCKET userS)
{
	try
	{
		while (true)
		{
			if (m_clients[userS] == nullptr)
			{
				throw std::exception("");
			}
			RequestInfo reqInfo;
			char header[5];// need to know the size fo the message before recv it and kecp it in buffer...
			if (!receiveAll(userS, header, 5))
			{
				throw std::exception("error in recv header data");
			}
			int messageLength = (Byte)header[1] << 24;
			messageLength |= (Byte)header[2] << 16; 
			messageLength |= (Byte)header[3] << 8;
			messageLength |= (Byte)header[4];

			//affter we get the length we can recv the message
			reqInfo.buff.resize(messageLength);
			if (!receiveAll(userS, (char*)reqInfo.buff.data(), messageLength))			{
				throw std::exception("error in recv mssage data");

			}
			reqInfo.id = (Byte)header[0];
			reqInfo.receivalTime = std::time(nullptr);
			reqInfo.userSocket = userS;
			if (m_clients[userS]->isRequestRelevant(reqInfo))// put the user requset in the handler taht now found on the handler fucatry and check if the this 'valid' request for this state before we even start to work on the packet
			{
				try
				{
					RequestResult handlerRes = m_clients[userS]->handleRequest(reqInfo);// affter give the info to to the handler and return the reponse to the user 

	
					sendAll(userS, (char*)handlerRes.response.data(), handlerRes.response.size());

					IRequestHandler* oldHandler = m_clients[userS];

					if (handlerRes.newHandler != oldHandler)
					{
						m_clients[userS] = handlerRes.newHandler;
						delete oldHandler;
					}
					else
					{
						m_clients[userS] = oldHandler;
					}
				}
				catch (const std::exception& e)
				{
					std::cout << "Exception in handler request part: " << e.what() << std::endl;

				}

			}
			else
			{
				std::cout << "user request not relevant!\n";
			}
		}
	}
	catch (const std::exception& e) {
		std::cout << "Exception in clientHandler: " << e.what() << std::endl;
		m_handleFactory.getLoginManager().log_off(userS);// log off whit the user socket and not whit the name...
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
