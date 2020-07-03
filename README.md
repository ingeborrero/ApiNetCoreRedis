# ApiNetCoreRedis
Api with Net Core 3.1 and implementation with Redis(NOSQL DB)


Consume end points:

1- Roulette/RegisterRoulette

- Example POST request:
{
    "name": "Name of Roulette"
}

2- Roulette/OpenRoulette

- Example GET request: Use FromQuery
/Roulette/OpenRoulette?id=1

3-Roulette/CreateBet (The EndPoint need the "UserId" header)

- Example POST request:
{
    "IdRoulette": 1,
    "Number": 16,
    "Color": "Rojo",
    "ValueBet": 1500
}

4-Roulette/CloseBets

- Example GET request:
/Roulette/CloseBets?id=1

5-Roulette/GetRoulettes

- Example GET request:
<<<<<<< HEAD
/Roulette/GetRoulettes
=======
/Roulette/GetRoulettes
>>>>>>> 7ee64fe1bbfc8ea7632af140a479a3b943bdb5be
