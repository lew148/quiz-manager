import React from 'react';
import { useField } from "react-form";

const TextField = ({ name, type }) => {
    const { getInputProps } = useField(name);

    return (
        <input className="form-control" {...getInputProps()} type={type} placeholder={name} />
    );
}

export default TextField;
