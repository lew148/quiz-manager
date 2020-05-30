import React from 'react';
import { post } from '../../Api';

const LogoutButton = () => {
    const handleClick = async () => {
        // eslint-disable-next-line no-restricted-globals
        var logoutComfirmed = confirm("Are you sure you want to logout?")
        if (logoutComfirmed) {
            await post("account/logout")
            window.location.reload();
        }
    }

    return (
        <button type="button" onClick={handleClick} className="btn btn-warning">Logout</button>
    );
};

export default LogoutButton;