import { AppBar, Box, IconButton, List, ListItem, Toolbar, Typography } from "@mui/material"
import { Menu } from '@mui/icons-material'
import ListItemButtonLink from "../Activities/ListItemButtonLink"

function Header(){

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
            >
                <Menu />
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
                    <ListItemButtonLink to={`/createActivity`}>Create Activity</ListItemButtonLink>
                </ListItem>
            </List>
            </Toolbar>
        </AppBar>
        </Box>
    )
}

export default Header