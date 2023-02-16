import React from "react";

import Footer from "../components/Footer";
import NavBar from "../components/NavBar";

import Article from "../utils/interfaces/Article";

import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

const ArticleContentScreen: React.FC<{}> = (): JSX.Element => {
    const navigate = useNavigate();

    const Article: Article = useSelector((state: any) => state.SelectedArticle);

    const closeArticle = () => {
        navigate("/");
    }

    return <>
        <NavBar />
        <div className="main-container" style={{ width: "80%", margin: "0 auto", padding: "2% 0 0 0" }}>
            <div className="article-content">
                <div className="article-header" style={{ display: "flex", justifyContent: "space-between", width: "40%" }}>
                    <div className="header-left">
                        <img src={Article.ImageUrl} style={{ width: "70%" }} alt="article image" />
                    </div>
                    <div className="header-right">
                        <h4 className="container-heading">{Article.ArticleName}</h4>
                        <p>{Article.DateCreated}</p>
                    </div>
                </div>
                <div className="article-body">

                </div>
                <button style={{ margin: "10px 0 10px 0" }} onClick={closeArticle} className="btn btn-danger">Close</button>
            </div>
        </div>
        <Footer />
    </>
}

export default ArticleContentScreen;
