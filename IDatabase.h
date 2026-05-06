#pragma once
#include <iostream>
//interface
class IDatabase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(std::string name) = 0;
	virtual int doesPasswordMatch(std::string pass1, std::string pass2) = 0;
	virtual int addNewUser(std::string name, std::string pass, std::string email) = 0;
};

