import React from 'react'
import { useAccount } from './useAccount'
import { Navigate, Outlet, useLocation } from 'react-router';
import { Typography } from '@mui/material';

function RequireAuth() {

    const {currentUser, isLoadingUser} = useAccount();

    const location = useLocation();

    if(isLoadingUser) return <Typography>Loading...</Typography>

    if(!currentUser) return <Navigate to='/login' state={{from: location}} />

  return (
    <Outlet/>
  )
}

export default RequireAuth