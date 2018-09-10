# Becomex code challenge

Rules of the challenge in [Challenge.docx](Challenge.docx)

To run the tests execute:

```
docker-compose -f docker-compose-test.yml up
```

To build and execute the container execute:

```
docker build -t robot .
docker run robot
```

The web page to operate the robot will be in http://localhost/swagger.