import React from 'react';
import { useForm } from "react-form";
import { post } from '../../Api';
import TextField from './Inputs/TextField';

const HandleSubmit = async (values) => {
    await post('login', values);
    window.location.reload();
}

const Login = () => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            HandleSubmit(values)
        }
    });

    return (
        <div className="d-flex justify-content-center">
            <Form>
                <div className="centered-text">
                    <span className="login-form-title" >Login</span>
                </div>
                <div className="form-input">
                    <TextField name="username" type="text" />
                </div>
                <div className="form-input">
                    <TextField name="password" type="password" />
                </div>
                <div className="centered-text">
                    <button className="btn btn-primary" type="submit">Submit</button>
                </div>
            </Form>
        </div>
    );
};

export default Login;