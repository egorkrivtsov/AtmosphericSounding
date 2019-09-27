﻿using System;
using System.IO;
using System.Linq;
using Common.Exceptions;
using Data.Reader.Interfaces;

namespace Data.Reader
{
    public class TextFileReader<TOut>
    {
        public string ColumnSeparator { get; set; } = "\t";

        public string LineSeparator { get; set; } = Environment.NewLine;

        public ITxtLinesMapping<TOut> Mapping { get; protected set; }

        public TextFileReader(ITxtLinesMapping<TOut> mapping)
        {
            Mapping = mapping;
        }

        public TextFileReader(ITxtLinesMapping<TOut> mapping, string columnSeparator)
            : this(mapping)
        {
            ColumnSeparator = columnSeparator;
        }

        public TextFileReader(ITxtLinesMapping<TOut> mapping, string columnSeparator, string lineSeparator) 
            : this(mapping, columnSeparator)
        {
            LineSeparator = lineSeparator;
        }

        public TOut Read(string fileName)
        {
            var text = GetText(fileName);

            if (String.IsNullOrWhiteSpace(text))
                throw new FileReadException($"Unable to read file: {fileName}");

            return ReadDataModel(text);
        }

        public TOut Read(Stream stream)
        {
            var text = GetText(stream);
            if (String.IsNullOrWhiteSpace(text))
                throw new FileReadException();
            return ReadDataModel(text);
        }

        public TOut ReadDataModel(string data)
        {
            return Mapping.Map(data.Split(LineSeparator,
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(d => d.Split(ColumnSeparator, StringSplitOptions.RemoveEmptyEntries)),
                default(TOut));
        }


        #region Private methods

        private string GetText(Stream stream)
        {
            string text;
            using (StreamReader sr = new StreamReader(stream))
            {
                text = sr.ReadToEnd();
            }

            return text;
        }

        private string GetText(string fileName)
        {
            string text;
            using (StreamReader sr = new StreamReader(fileName))
            {
                text = sr.ReadToEnd();
            }

            return text;
        }

        #endregion
    }
}