import { AppBar, Box, IconButton, List, ListItem, Toolbar, Typography, useTheme } from "@mui/material"
import { DarkMode, LightMode } from '@mui/icons-material'
import ListItemButtonLink from "../Activities/ListItemButtonLink"
import { useAccount } from "./useAccount"

type Props = {
    toggleDarkMode: () => void
}


function Header({toggleDarkMode} : Props){

    const theme = useTheme()
    const {currentUser} = useAccount();

    return (
        <Box sx={{ flexGrow: 1 }}>
        <AppBar position="static">
            <Toolbar>
            <IconButton
                size="large"
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
                onClick={toggleDarkMode}
            >
                {theme.palette.mode === 'dark'
                ? <LightMode/>
                : <DarkMode/>}
            </IconButton>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                Event Management App
            </Typography>
            <List sx={{display: 'flex', flexDirection: 'row'}}>
                <ListItem>
                    <ListItemButtonLink to={`/`}>Home</ListItemButtonLink>
                </ListItem>
                <ListItem>
                    <ListItemButtonLink to={`/activities`}>Activities</ListItemButtonLink>
                </ListItem>
                <ListItem>
                    {currentUser 
                    ? <ListItemButtonLink to={`/createActivity`}>Create Activity</ListItemButtonLink> 
                    : <ListItemButtonLink to={`/login`}>Login</ListItemButtonLink>}
                </ListItem>
                {currentUser && 
                <ListItem>
                    <ListItemButtonLink to={`/activities`}>Logout</ListItemButtonLink>
                </ListItem>}
            </List>
            </Toolbar>
        </AppBar>
        </Box>
    )
}

export default Header