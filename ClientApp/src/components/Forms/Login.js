import React from 'react';
import { withRouter } from 'react-router-dom';
import { useForm } from "react-form";
import { post } from '../../Api';
import TextField from './Inputs/TextField';

const HandleSubmit = async (history, values) => {
    await post('login', values);
    window.location.reload();
}

const Login = ({ history }) => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            HandleSubmit(history, values)
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
                    <button class="btn btn-primary" type="submit">Submit</button>
                </div>
            </Form>
        </div>
    );
};

export default withRouter(Login);