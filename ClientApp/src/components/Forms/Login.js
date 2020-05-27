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
        },
        debugForm: true
    });

    return (
        <div className="d-flex justify-content-center">
            <Form>
                <span className="login-form-title p-5" >Login</span>
                <TextField name="username" />
                <TextField name="password" />
                <div className="submitButton">
                    <button type="submit">
                        Submit
                    </button>
                </div>
            </Form>
        </div>
    );
};

export default withRouter(Login);