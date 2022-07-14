import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useNavigate } from "react-router-dom";
import { register } from "../modules/authManager";

export default function Register() {
  const navigate = useNavigate();

  const [name, setName] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
    e.preventDefault();
    if (password && password !== confirmPassword) {
      alert("Passwords don't match!");
    } else {
      const User = {
        name,
        email,
      };
      register(User, password).then(() => navigate("/"));
    }
  };

  return (
    <Form onSubmit={registerClick}>
      <fieldset>

        <FormGroup>
          <Label htmlFor="Name">Name</Label>
          <Input
            id="Name"
            type="text"
            onChange={(e) => setName(e.target.value)}
          />
        </FormGroup>

        <FormGroup>
          <Label for="Email">Email</Label>
          <Input
            id="Email"
            type="text"
            onChange={(e) => setEmail(e.target.value)}
          />
        </FormGroup>

        <FormGroup>
          <Label for="Password">Password</Label>
          <Input
            id="Password"
            type="password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </FormGroup>

        <FormGroup>
          <Label for="ConfirmPassword">Confirm Password</Label>
          <Input
            id="ConfirmPassword"
            type="password"
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
        </FormGroup>

        <FormGroup>
          <Button>Register</Button>
        </FormGroup>

      </fieldset>
    </Form>
  );
}
